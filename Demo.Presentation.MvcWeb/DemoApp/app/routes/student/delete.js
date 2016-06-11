import Ember from 'ember';

export default Ember.Route.extend({
    model(params) {
        var student = this.store.peekRecord('student', params.student_id);
        if (student) {
            return student;
        }
        toastr.error('Can not get any student with specified Id.');
        this.transitionTo('student');
    },
    renderTemplate() {
        this.render('student/add', {controller: 'student/delete'});
    }
});
