import Ember from 'ember';

export default Ember.Controller.extend({
  title: 'Add Student',
  submitButtonText: 'Add',
  actions: {
    save() {
      // save to server
      //alert('add');
      var student = this.store.createRecord('student', this.get('model'));
      student.save()
          .then(response => Ember.set(student, 'id', response.get('id')))
          .catch(response => {
              student.rollbackAttributes();
          });
    },
    required(data, event) {
      if (!event.target.value) {
        this.get('errors').pushObject({ message: `${event.target.name} is required`});
      }
    }
  }
});
