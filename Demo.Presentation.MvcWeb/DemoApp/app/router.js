import Ember from 'ember';
import config from './config/environment';

const Router = Ember.Router.extend({
    location: config.locationType,
    rootURL: '/home/index/'
});

Router.map(function() {
  this.route('student');
  this.route('about');
});

export default Router;
