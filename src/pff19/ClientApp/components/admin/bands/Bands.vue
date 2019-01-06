<template>
    <div>
        <h1>Bands</h1>
        <router-link
            to="bands/add"
            >
            <i class="fa fa-add fa-1x pull-right"></i>hinzufügen
        </router-link>
        <div class="card-columns">
            <div class="card" v-for="faq in all" :key="faq.id">
                <div>
                    {{ faq.id }}
                </div>
                <div>                
                    {{ faq.questionDe }}
                </div>
                    <div >
                        <i class="fa fa-remove fa-1x pull-right" @click="remove(faq.id)"></i>
                        <!-- <router-link 
                        :to="{ name: 'adminFAQEdit', params: {order: faq.order }}"
                        ><i class="fa fa-edit fa-1x pull-right"></i></router-link> -->
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
</style>
