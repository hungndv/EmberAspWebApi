export function initialize(/* application */) {
    // application.inject('route', 'foo', 'service:foo');
    $.blockUI.defaults.baseZ = 2000;
}

export default {
    name: 'third-parties-init',
    initialize
};
