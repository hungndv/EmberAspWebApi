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
    save() {
      // save to server peekRecord
      var model = this.get('model');
      var origin = this.store.peekRecord('student', model.id);
      origin.set('firstName', model.firstName);
      origin.set('lastName', model.lastName);
      origin.save()
        .then(response => {
            $('.modal').modal('hide');
        })
        .catch(response => {
            origin.rollbackAttributes();
        });
    }
  }
});
