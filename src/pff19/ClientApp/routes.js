import CounterExample from 'components/counter-example';
import Impressum from 'components/Impressum';
import HomePage from 'components/home/Home';
import Sponsors from 'components/sponsors/SponsorList';

export const routes = [
    { name: 'home', path: '/', component: HomePage, display: 'Home'},
    { name: 'counter', path: '/counter', component: CounterExample, display: 'Counter'},
    { name: 'sponsors', path: '/sponsors', component: Sponsors, display: 'Sponsoren'},
    { name: 'impressum', path: '/impressum', component: Impressum, display: 'Impressum'}
];