import Ember from 'ember';
import config from './config/environment';

const Router = Ember.Router.extend({
    location: config.locationType,
    rootURL: '/home/index/'
});

Router.map(function() {
    this.route('student', function() {
      this.route('add');
      this.route('edit', { path: '/edit/:student_id' });
      this.route('delete', { path: '/delete/:student_id' });
    });
    this.route('about');
});

export default Router;
