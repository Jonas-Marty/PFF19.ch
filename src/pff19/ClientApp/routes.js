import CounterExample from 'components/counter-example';
import Impressum from 'components/Impressum';
import HomePage from 'components/home/Home';
import Sponsors from 'components/sponsors/SponsorList';

export const routes = [
    { path: '/', component: HomePage, display: 'Home', style: 'glyphicon glyphicon-home' },
    { path: '/counter', component: CounterExample, display: 'Counter', style: 'glyphicon glyphicon-education' },
    { path: '/sponsors', component: Sponsors, display: 'Sponsoren', style: 'glyphicon glyphicon-th-list' }
];

export const helperRoutes = {
    impressum: { path: '/impressum', component: Impressum, display: 'Impressum', style: 'glyphicon glyphicon-th-list' }
}