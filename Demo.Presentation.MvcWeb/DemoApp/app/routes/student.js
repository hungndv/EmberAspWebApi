import Ember from 'ember';

var students = [{
  id: 1,
  firstName: 'Grand Old Mansion',
  lastName: 'Veruca Salt'
},{
  id: 2,
  firstName: 'Grand Old Mansion2',
  lastName: 'Veruca Salt2'
}];

export default Ember.Route.extend({
	model() {
		return this.store.findAll('student');
		//return students;
	},
  actions: {
    openNewModal(name) {
      this.controllerFor('add-student').set('errors', []);
      this.render(name, {
        into: 'student',
        outlet: 'modal',
        model: {firstName:'', lastName:''},
        controller: 'add-student'
      });
    },
    openEditModal(name, model) {
      var copy = {id: model.get('id'), firstName: model.get('firstName'), lastName: model.get('lastName')};
      this.controllerFor('edit-student').set('errors', []);
      this.render(name, {
        into: 'student',
        outlet: 'modal',
        model: copy,
        controller: 'edit-student'
      });
    },
    openDeleteModal(name, model) {
      this.controllerFor('delete-student').set('errors', []);
      this.render(name, {
        into: 'student',
        outlet: 'modal',
        model: model,
        controller: 'delete-student'
      });
    },
    removeModal() {
      this.disconnectOutlet({
        outlet: 'modal',
        parentView: 'student'
      });
    }
  }
});
