<template>
    <div class="container">
        <div class="row">
        <div class="col">
            <h1>Bands</h1>
        </div>
        <div class="col">
            <form>
                <div class="form-group">
                    <label for="days">Select a year</label>
                    <select id="days" class="form-control" v-model="selectedDay" >
                        <option v-for="day in days" :key="day" :value="day" :selected="day === selectedDay">{{
                            day
                        }}</option>
                    </select>
                </div>
            </form>
        </div>
        </div>
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

    data() {
        return {
            filteredBands: [],
            selectedDay: 'Alle',
            days: ['Alle', 'Freitag', 'Samstag', 'Sonntag']
        }
    },

    methods: {
        ...mapActions('bands', ['load', 'loadCurrentBand']),
        filterBands(e) {
            console.log(e, 'asdfjgdsf')
        }
    },

    computed: {
        ...mapGetters('bands', ['all']),
        orderedBands() {
            return this.all.sort((a, b) => a.order - b.order)
        }
    },

    created() {
        this.load()
    },
    mounted() {
        this.filteredBands = this.all
        console.log(this.orderedBands)
    },
    watch: {
        selectedDay() {
            
        }
    } 
}
</script>

<style lang="scss" scoped>
.container {
    padding-top: 100px;
}
</style>
