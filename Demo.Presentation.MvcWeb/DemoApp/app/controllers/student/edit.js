import Ember from 'ember';

export default Ember.Controller.extend({
    title: 'Edit Student',
    submitButtonText: 'Edit',
  
    init() {
        this._super(...arguments);
        this.errors = [];
    },

    didUpdateAttrs() {
        this._super(...arguments);
        this.set('errors', []);
    },
  
    actions: {
        save(modal) {
            this.model.save()
              .then(response => {
                  modal.modal('hide');
                  this.transitionToRoute('student');
              })
              .catch(response => {
                  this.model.rollbackAttributes();
              });
        },
        cancel(modal){
            this.model.rollbackAttributes();
            modal.modal('hide');
        }
    }
});
