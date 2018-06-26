import CounterExample from 'components/counter-example';
import FetchData from 'components/fetch-data';
import HomePage from 'components/home/Home';
import Sponsors from 'components/sponsors/SponsorList';

export const routes = [
    { path: '/', component: HomePage, display: 'Home', style: 'glyphicon glyphicon-home' },
    { path: '/counter', component: CounterExample, display: 'Counter', style: 'glyphicon glyphicon-education' },
    { path: '/fetch-data',component: FetchData, display: 'Fetch data', style: 'glyphicon glyphicon-th-list' },
    { path: '/sponsors', component: Sponsors, display: 'Sponsoren', style: 'glyphicon glyphicon-th-list' }
]