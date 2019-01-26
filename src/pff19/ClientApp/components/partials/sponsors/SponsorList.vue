<template>
    <div class="sponsors container" v-if="mainSponsors && mainSponsors.length > 0">
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
           'mainSponsors'
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
    .sponsors {
        width: 100%;
        margin-top: 50px;
    }

</style>

