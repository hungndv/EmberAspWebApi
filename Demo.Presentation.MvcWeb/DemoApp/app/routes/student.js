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
        removeModal() {
            this.transitionTo('student');
        }
    }
});
