<template>
    <div class="container">
        <text-de v-if="language === 'de'"></text-de>
        <text-fr v-if="language === 'fr'"></text-fr>
        <div class="sponsors" v-if="mainSponsors && mainSponsors.length > 0">
            <h2>{{ $t('lang.components.home.sponsors.main_sponsors') }}</h2>
            <div class="row">
                <app-sponsor
                    v-for="sponsor in mainSponsors"
                    :key="sponsor.id"
                    :sponsor="sponsor"
                >   
                </app-sponsor>
                </div>
        </div>

        <div class="sponsors" v-if="coSponsors && coSponsors.length > 0">
            <h2>{{ $t('lang.components.home.sponsors.co_sponsors') }}</h2>
            <div class="row">
                <app-sponsor
                    v-for="sponsor in coSponsors"
                    :key="sponsor.id"
                    :sponsor="sponsor"
                >   
                </app-sponsor>
                </div>
        </div>

        <div class="sponsors" v-if="partner && partner.length > 0">
            <h2>{{ $t('lang.components.home.sponsors.partner') }}</h2>
            <div class="row">
                <app-sponsor
                    v-for="sponsor in partner"
                    :key="sponsor.id"
                    :sponsor="sponsor"
                >   
                </app-sponsor>
                </div>
        </div>

        <div class="sponsors" v-if="infrapartner && infrapartner.length > 0">
            <h2>{{ $t('lang.components.home.sponsors.infrapartner') }}</h2>
            <div class="row">
                <app-sponsor
                    v-for="sponsor in infrapartner"
                    :key="sponsor.id"
                    :sponsor="sponsor"
                >   
                </app-sponsor>
                </div>
        </div>

        <div class="sponsors" v-if="scoutpartner && scoutpartner.length > 0">
            <h2>{{ $t('lang.components.home.sponsors.scoutpartner') }}</h2>
            <div class="row">
                <app-sponsor
                    v-for="sponsor in scoutpartner"
                    :key="sponsor.id"
                    :sponsor="sponsor"
                >   
                </app-sponsor>
                </div>
        </div>

        <div class="sponsors" v-if="patron && patron.length > 0">
            <h2>{{ $t('lang.components.home.sponsors.patron') }}</h2>
            <div class="row">
                <goenner
                    v-for="sponsor in patron"
                    :key="sponsor.id"
                    :sponsor="sponsor"
                >   
                </goenner>
                </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios'
import { mapActions, mapGetters } from 'vuex'
import Sponsor from './Sponsor'
import Goenner from './Goenner'
import textDe from './TextDe'
import textFr from './TextFr'


export default {
     methods: {
        ...mapActions('sponsors', [
            'load'
        ]),
    }, 

    computed: {
       ...mapGetters('sponsors',[
           'mainSponsors',
           'coSponsors',
           'partner',
           'patron',
           'infrapartner',
           'scoutpartner'
       ]),

       ...mapGetters([
           'language'
       ])

    },

    created() {
        this.load();
    },

    components: {
        'app-sponsor': Sponsor,
        Goenner,
        textFr,
        textDe
    }

}
</script>

<style lang="scss" scoped>
    .container {
        padding-top: 100px;
        min-height: 700px;
    }

    .sponsors {
        width: 100%;
        margin-top: 50px;
    }

</style>

