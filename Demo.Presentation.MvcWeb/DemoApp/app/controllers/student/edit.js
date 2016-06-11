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
            $.blockUI();
            this.model.save()
              .then(response => {
                  toastr.success('success');
                  modal.modal('hide');
                  this.transitionToRoute('student');
                  $.unblockUI();
              })
              .catch(response => {
                  this.model.rollbackAttributes();
                  toastr.error('error');
                  $.unblockUI();
              });
        },
        cancel(modal){
            this.model.rollbackAttributes();
            modal.modal('hide');
        }
    }
});
