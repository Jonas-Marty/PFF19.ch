<template>
    <div>
        <app-slideshow> </app-slideshow>
        <description></description>
    </div>
</template>

<script>
import Vue from 'vue';

import Slideshow from './Slideshow'
import Description from './Description'


import { mapActions, mapGetters  } from 'vuex';


export default {
    data() {
        return {
        }
    },

    computed: {
        ...mapGetters([
            'language'
        ])
    },

    components: {
        'app-slideshow': Slideshow,
        Description
    }
}
</script>

<style>
</style>