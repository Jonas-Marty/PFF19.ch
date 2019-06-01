<template>
    <div class="container">
        <h1>Bands</h1>
        <div class="card-columns">
            <div class="card" v-for="band in orderedBands" :key="band.id">
                <router-link :to="{ name: 'band', params: { id: band.id, name: band.name } }">
                    <img
                        class="card-img-top"
                        :src="`/assets/bands/thumbnail/${band.imageThumbnail}`"
                        :alt="band.name"
                    />
                </router-link>
                <div class="card-body">
                    <router-link :to="{ name: 'band', params: { id: band.id, name: band.name } }">
                        <h5 class="card-title">{{ band.name }}</h5>
                    </router-link>
                    <h6>{{ band.playTime }}</h6>
                    <p class="card-text"></p>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
import { mapActions, mapGetters } from 'vuex'
import axios from 'axios'

export default {
    metaInfo() {
        return {
            title: `| ${this.$i18n.t('lang.navigation.bandsOverview')}`
        }
    },
    methods: {
        ...mapActions('bands', ['load', 'loadCurrentBand'])
    },

    computed: {
        ...mapGetters('bands', ['all']),
        orderedBands() {
            return this.all.sort((a, b) => a.order - b.order)
        }
    },

    created() {
        this.load()
    }
}
</script>

<style lang="scss" scoped>
.container {
    padding-top: 100px;
}
</style>
