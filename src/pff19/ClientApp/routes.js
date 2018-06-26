import Impressum from 'components/Impressum';
import HomePage from 'components/home/Home';
import Sponsors from 'components/sponsors/SponsorList';
import FAQ from 'components/faq/FAQ';
import Organisation from 'components/Organisation';
import Helfer from 'components/helper/Helfer';

export const routes = [
    { name: 'home', path: '/', component: HomePage, display: 'Home', important: true},
    { name: 'sponsors', path: '/sponsors', component: Sponsors, display: 'Sponsoren', important: true},
    { name: 'faq', path: '/faq', component: FAQ, display: 'FAQ', important: true},
    { name: 'organisation', path: '/organisation', component: Organisation, display: 'Organisation', important: true},
    { name: 'helfer', path: '/helfer', component: Helfer, display: 'Helfer', important: true},


    { name: 'impressum', path: '/impressum', component: Impressum, display: 'Impressum'},
    { name: 'news', path: '/news', component: Impressum, display: 'Impressum'}
];