import Ember from 'ember';

export default Ember.Controller.extend({
  title: 'Add Student',
  submitButtonText: 'Add',
  model: null,
  actions: {
    save() {
      // save to server
      //alert('add');
      var student = this.store.createRecord('student', this.get('model'));
      var self = this;
      student.save()
          .then(response => Ember.set(student, 'id', response.get('id')))
          .catch(response => {
              //student.rolledBack();
              student.rollbackAttributes();
          });
    }
  }
});
