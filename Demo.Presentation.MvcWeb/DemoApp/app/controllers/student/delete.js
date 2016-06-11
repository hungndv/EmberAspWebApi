import Ember from 'ember';

export default Ember.Controller.extend({
    title: 'Delete Student',
    submitButtonText: 'Delete',
    isDelete: true,
    actions: {
        save(modal) {
            this.model.deleteRecord();
            this.model.save()
                .then(response => {
                    modal.modal('hide');
                }).catch(response => {
                    student.rollbackAttributes();
                });
        }
    }
});
