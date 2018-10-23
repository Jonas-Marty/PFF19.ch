<template>
    <div>
        <h1>Alle Kontakte</h1>

        <div class="list-group">
            <div class="list-group-item d-flex justify-content-between align-items-right" v-for="contact in all" :key="contact.id">
            <div>
                {{ contact.firstName }}, {{ contact.lastName }}
            </div>
            
            <div>
                {{ contact.mail }}
            </div>
            <div>
                {{ contact.text }}
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
        ...mapActions('contact', [
            'load',
        ]),
    }, 

    computed: {
       ...mapGetters('contact',[
           'all'
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
