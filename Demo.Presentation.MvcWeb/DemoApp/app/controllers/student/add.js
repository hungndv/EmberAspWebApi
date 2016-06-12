import Ember from 'ember';

export default Ember.Controller.extend({
    title: 'Add Student',
    submitButtonText: 'Add',
    
    nameChanged: Ember.observer('model.firstName', 'model.lastName', function() {
        this.set('errors', []);
        if (!this.get('model.firstName')) {
            this.get('errors').pushObject({ message: `FirstName is required.`});
        }
        if (!this.get('model.lastName')) {
            this.get('errors').pushObject({ message: `LastName is required.` });
        }
    }),
  
    actions: {
        save(modal) {
            $.blockUI();
            Ember.run.later(() => {
                var student = this.store.createRecord('student', {firstName: this.model.firstName, lastName: this.model.lastName});
                student.save()
                    .then(response => {
                        Ember.set(student, 'id', response.get('id'));
                        toastr.success('success');
                        modal.modal('hide');
                        this.transitionToRoute('student');
                        $.unblockUI();
                    })
                    .catch(error => {
                        this.set('errors', []);
                        error.errors.forEach(errorMsg => {
                            this.get('errors').pushObject({ message: errorMsg});
                        });
                        student.rollbackAttributes();
                        toastr.error('error');
                        $.unblockUI();
                    });
            }, 2000);

        },
        cancel(modal){
            //this.model.rollbackAttributes();
            modal.modal('hide');
        }
    }
});
