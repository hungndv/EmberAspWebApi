import Ember from 'ember';

export default Ember.Controller.extend({
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
            .then(response => {
                $('.modal').modal('hide');
            }).catch(response => {
                //debugger;
                student.rollbackAttributes();
            });
    }
  }
});
