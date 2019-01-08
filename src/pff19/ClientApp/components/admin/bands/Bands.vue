<template>
    <div>
        <h1>Bands</h1>
        <router-link
            to="bands/add"
            >
            <i class="fa fa-add fa-1x pull-right"></i>hinzufügen
        </router-link>
        <div class="card-columns">
            <div class="card" v-for="band in all" :key="band.id">
                <img class="card-img-top" :src="`/assets/bands/images/${band.imageThumbnail}`" alt="Card image cap">
                <div class="card-body"> 
                    <h5 class="card-title">{{ band.name }}</h5>
                    <p class="card-text">               
                        {{ band.descriptionDe | shorten(150)}}
                    </p>
                        <router-link 
                         class="card-link"
                            :to="{ name: 'band', params: {id: band.id }}"
                        >
                        View
                        </router-link>
                        <router-link 
                         class="card-link"
                            :to="{ name: 'adminBandsEdit', params: {id: band.id }}"
                        >
                        Edit
                        </router-link>

                        <i class="fa fa-remove fa-1x pull-right" @click="remove(band.id)"></i>

                </div>
                    <div >
   
                </div>
            </div>
        </div>
    </div>
</template>
<script>
import { mapActions, mapGetters } from 'vuex';
import axios from 'axios';


export default {

    methods: {
        ...mapActions('bands', [
            'load',
            'remove'
        ]),
    }, 

    computed: {
       ...mapGetters('bands',[
           'all'
       ])
    },

    created() {
        this.load()
    },
    
    
}
</script>

<style lang="scss" scoped>
.fa-remove {
    cursor: pointer;
}

.fa-edit{
    margin-right: 5px
}

.card-img-top {
    border-bottom: 2px solid #212529;
}
</style>
