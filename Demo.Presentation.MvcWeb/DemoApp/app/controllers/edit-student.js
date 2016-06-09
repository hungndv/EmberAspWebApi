import Ember from 'ember';

export default Ember.Controller.extend({
  title: 'Edit Student',
  submitButtonText: 'Edit',
  model: null,
  actions: {
    save() {
      // save to server peekRecord
      var model = this.get('model');
      var origin = this.store.peekRecord('student', model.id);
      origin.set('firstName', model.firstName);
      origin.set('lastName', model.lastName);
      origin.save()
        .then(response => {
            
        })
        .catch(response => {
            origin.rollbackAttributes();
        });
    }
  }
});
