import Ember from 'ember';

export default Ember.Controller.extend({
  model: null,
  title: 'Delete Student',
  submitButtonText: 'Delete',
  isDelete: true,
  actions: {
    save() {
      // save to server
      var model = this.get('model');
      var student = this.store.peekRecord('student', model.id);
        student.deleteRecord();
        //student.get('isDeleted'); // => true
        student.save()
            .then(response => {}).catch(response => {
                //debugger;
                student.rollbackAttributes();
            });
    }
  }
});
