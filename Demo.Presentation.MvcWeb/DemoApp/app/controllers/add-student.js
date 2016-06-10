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
        this.get('errors').pushObject({ message: `LastName is required.`});
    }
  }),
  
  actions: {
    save() {
      var student = this.store.createRecord('student', this.get('model'));
      student.save()
          .then(response => {
              Ember.set(student, 'id', response.get('id'));
              $('.modal').modal('hide');
          })
          .catch(error => {
              this.set('errors', []);
              error.errors.forEach(errorMsg => {
                this.get('errors').pushObject({ message: errorMsg});
              });
              student.rollbackAttributes();
          });
    }
  }
});



