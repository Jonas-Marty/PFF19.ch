<template>
    <div class="container">
        <h1>{{ $t(`lang.components.organisation.organisation`) }}</h1>
        <text-de v-if="language === 'de'"></text-de>
        <text-fr v-if="language === 'fr'"></text-fr>
        <div class="team">
            <h2>Das Team</h2>
            <div class="row members">
                <div class="member col-6 col-md-4 col-lg-3" v-for="image in images" :key="image.scoutName">
                    <div class="card">
                        <img class="card-img-top" :src="require(`../../assets/images/portraits/${image.scoutName}-min.jpg`)" :alt="image.scoutName">
                        <div class="card-body">
                            <p class="card-text"><b>{{image.scoutName}}</b>, {{image.name}}<br>{{ $t(`lang.components.organisation.${image.ressort}`) }}<br></p>
                            <blockquote class="blockquote mb-0">
                                <footer class="blockquote-footer">{{image.email}}</footer>
                            </blockquote>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { mapGetters } from 'vuex'
import i18n from '../../locales';
import textDe from './TextDe'
import textFr from './TextFr'
export default {
    data () {
        return {
            images: [
                {
                    name: "David Bernet",
                    scoutName: 'Echo',
                    ressort: 'co_president',
                    email: 'echo@pff19.ch'
                },
                {
                    name: "Fabio Di Rocco",
                    scoutName: 'Wum',
                    ressort: 'co_president',
                    email: 'wum@pff19.ch'
                },
                {   
                    name: "Viviane Lott",
                    scoutName: 'Aviera',
                    ressort: 'secretariat',
                    email: 'aviera@pff19.ch'
                },
                {
                    name: "Josias Zeller",
                    scoutName: 'Fuego',
                    ressort: 'secretariat',
                    email: 'fuego@pff19.ch'
                },
                {
                    name: "Thomas Bauknecht",
                    scoutName: 'Snoopy',
                    ressort: 'finances',
                    email: 'snoopy@pff19.ch'
                    
                },
                {
                    name: "Desirée Blass",
                    scoutName: 'Soraya',
                    ressort: 'finances',
                    email: 'soraya@pff19.ch'
                },
                {
                    name: "Oliver Bernet",
                    scoutName: 'Pluto',
                    ressort: 'communication',
                    email: 'pluto@pff19.ch'
                },
                {
                    name: "Tobias Oechslin",
                    scoutName: 'Splash',
                    ressort: 'sponsoring',
                    email: 'splash@pff19.ch'
                },
                {
                    name: "Larissa Meister",
                    scoutName: 'Rajko',
                    ressort: 'programm',
                    email: 'rajko@pff19.ch'
                },
                {
                    name: "Stefan Messmer",
                    scoutName: 'Pixel',
                    ressort: 'programm',
                    email: 'pixel@pff19.ch'
                },
                {
                    name: "Jelena Hess",
                    scoutName: 'Varuna',
                    ressort: 'bands',
                    email: 'varuna@pff19.ch'
                },
                {
                    name: "Matthias Rothmayr",
                    scoutName: 'Piccolo',
                    ressort: 'infrastructure',
                    email: 'piccolo@pff19.ch'
                },
                {
                    name: "Meret Tuor",
                    scoutName: 'Baghira',
                    ressort: 'foot_beverage',
                    email: 'baghira@pff19.ch'
                },
                {
                    name: "Simon Flückiger",
                    scoutName: 'Dwalin',
                    ressort: 'foot_beverage',
                    email: 'dwalin@pff19.ch'
                },
                {
                    name: "Flurina Mäder",
                    scoutName: 'Karibu',
                    ressort: 'staff',
                    email: 'karibu@pff19.ch'
                },
                {
                    name: "Simone Scherberger",
                    scoutName: 'Momo',
                    ressort: 'staff',
                    email: 'momo@pff19.ch'
                },
                {
                    name: "Davina Biella",
                    scoutName: 'Joya',
                    ressort: 'staff',
                    email: 'joya@pff19.ch'
                },
                {
                    name: "Anna Rusch",
                    scoutName: 'Moneypenny',
                    ressort: 'security',
                    email: 'moneypenny@pff19.ch'
                },
            ]
        }
    },

    computed: {
       ...mapGetters([
           'language'
       ])
    },

    components: {
        textFr,
        textDe
    }

}
</script>

<style lang="scss" scoped>
    .container {
        padding-top: 100px;
        min-height: 800px;
    }

    .member {
        margin-top: 30px;
    }

    .team {
        margin-top: 50px;
    }

</style>
