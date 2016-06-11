import Ember from 'ember';

export default Ember.Route.extend({
    model(params) {
        var student = this.store.peekRecord('student', params.student_id);
        return student;
    },
    renderTemplate() {
        this.render('student/add', {controller: 'student/edit'});
    }
});
