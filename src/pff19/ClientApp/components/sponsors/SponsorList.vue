<template>
    <div class="container">
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

        <div class="sponsors" v-if="patron && patron.length > 0">
            <h2>{{ $t('lang.components.home.sponsors.patron') }}</h2>
            <div class="row">
                <app-sponsor
                    v-for="sponsor in patron"
                    :key="sponsor.id"
                    :sponsor="sponsor"
                >   
                </app-sponsor>
                </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios'
import { mapActions, mapGetters } from 'vuex'
import Sponsor from './Sponsor.vue'


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
           'patron'
       ])
    },

    created() {
        this.load();
    },

    components: {
        'app-sponsor': Sponsor
    }

}
</script>

<style lang="scss" scoped>
    .container {
        padding-top: 50px;
        min-height: 700px;
    }

    .sponsors {
        width: 100%;
        margin-top: 50px;
    }

</style>

