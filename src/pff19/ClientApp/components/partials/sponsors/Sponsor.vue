<template>
    <div class="sponsor col-10 col-12 col-md-4">
            <a :href="sponsor.link" target="_blank">
            <div class="sponsor-img-wrapper">
                <img :src="imagePath" :alt="sponsor.name" class="sponsor-img mx-auto"/>
            </div>
            </a>
    </div>
</template>

<script>
import axios from 'axios'
import { mapActions, mapGetters } from 'vuex'

export default {
    props: ['sponsor'],

     methods: {
        ...mapActions('sponsors', [
            'load'
        ]),
    }, 

    computed: {
       ...mapGetters('sponsors',[
           'mainSponsors'
       ]),
       
        imagePath () {
            return `/assets/sponsors/images/${this.sponsor.logo}`;
        },
    },

    created() {
        this.load();
    },

}
</script>

<style lang="scss" scoped>
    .sponsor-img {
        display: block;
        margin: auto;
        max-height: 200px;
        max-width: 100%;
    }

    .sponsor {
        padding: 5px;
    }

    .sponsor-img-wrapper {
        padding: 15px;
        margin-top: 10px;
    }

</style>

