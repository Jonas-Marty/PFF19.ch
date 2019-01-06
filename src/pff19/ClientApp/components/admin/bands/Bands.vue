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
                        <a href="#" class="card-link">View</a>
                        <router-link 
                         class="card-link"
                            :to="{ name: 'adminBandsEdit', params: {id: band.id }}"
                        >
                        Edit
                        </router-link>

                        <a href="#" class="card-link" @click="remove(band.id)">Delete</a>
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
