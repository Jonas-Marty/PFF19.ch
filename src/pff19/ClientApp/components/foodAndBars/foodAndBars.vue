<template>
    <div class="myContainer">
        <slideshow
            :images="`assets/bars/images/${this.getCurrentBar.imageLarge}`"
            :imageMobile="`assets/bars/mobile/${this.getCurrentBar.imageMobile}`"
        />
        <div class="container">
            <div class="row back">
                <div class="col">
                    <router-link class="btn btn-outline-primary" :to="{ name: 'foodAndBarsOverview' }"
                        >All Food&Bars</router-link
                    >
                </div>
            </div>
            <h1 class="title">{{ language === 'de' ?this.getCurrentBar.nameDe : this.getCurrentBar.nameFr }}</h1>

            <div class="row">
                <div class="col-12 text-content" v-html="description"></div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios'
import { mapGetters, mapActions } from 'vuex'

import Slideshow from 'components/partials/Slideshow'
export default {
    metaInfo() {
        return {
            title: `| ${this.language === 'de' ? this.getCurrentBar.nameDe : this.getCurrentBar.nameFr}`
        }
    },
    data() {
        return {
            bars: {}
        }
    },

    components: {
        Slideshow
    },

    methods: {
        ...mapActions('bars', ['loadCurrentBar'])
    },

    mounted() {
        this.loadCurrentBar(this.$route.params.id)
    },

    computed: {
        ...mapGetters('bars', ['getCurrentBar']),
        ...mapGetters(['language']),

        description() {
            return this.language === 'de'
                ? this.getCurrentBar.descriptionDe
                : this.getCurrentBar.descriptionFr
        }
    }
}
</script>

<style lang="scss" scoped>
h1 {
    margin-bottom: 20px;
}

.date {
    margin-bottom: 30px;
}

.back {
    margin-bottom: 30px;
}

.title {
    margin-bottom: 40px;
    margin-right: 20px;
    display: inline-block;
}

.title-playtime {
    display: inline-block;
}

.bar-image {
    max-height: 100%;
    max-width: 100%;
}

.myContainer {
    padding-top: 40;
}
.container {
    margin-top: 30px;
}

@media (max-width: 768px) {
    .text-content {
        margin-bottom: 20px;
    }
    .slideshow {
        height: 320px;
    }
}
</style>
