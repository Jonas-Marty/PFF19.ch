<template>
    <div>
        <h1>Sponsoren</h1>
        <router-link
            to="sponsoring/add"
            >
            <i class="fa fa-add fa-1x pull-right"></i>hinzufügen
        </router-link>
        <div class="list-group">
            <div class="list-group-item d-flex justify-content-between " v-for="sponsor in all" :key="sponsor.id">
                <div>
                    {{ status[sponsor.status] }}
                    <b>{{ sponsor.name }}</b>
                </div>
                    <div>
                        <i class="fa fa-remove fa-1x pull-right" @click="remove(sponsor.id)"></i>
                        <router-link 
                        :to="{ name: 'adminSponsoringEdit', params: {id: sponsor.id }}"
                        ><i class="fa fa-edit fa-1x pull-right"></i></router-link>
                </div>
            </div>
        </div>

    </div>
</template>
<script>
import { mapActions, mapGetters } from 'vuex';
import axios from 'axios';


export default {

    data (){
        return {
            status: {
                0: 'Hauptsponsor',
                1: 'Co-Sponsor',
                2: 'Partner',
                3: 'Gönner',
            }
        }
    },

    methods: {
        ...mapActions('sponsors', [
            'load',
            'remove'
        ]),
    }, 

    computed: {
       ...mapGetters('sponsors',[
           'all',
           'mainSponsors'
       ])
    },

    created() {
        this.load();
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
</style>
