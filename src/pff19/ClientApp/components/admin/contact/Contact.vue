<template>
    <div>
        <h1>Kontaktanfragen (neuste zuerst)</h1>
        <div class="list-group">
            <div class="list-group-item"  v-for="contact in orderedContacts" :key="contact.id">
                    <div class="card-body">
                        <h5 class="card-title">
                            {{ contact.firstName }}, {{ contact.lastName }}
                        </h5>
                        <h6 class="card-subtitle mb-2 text-muted">{{ contact.mail }}, {{ contact.submitedAt | formateDate }}</h6>
                        <p class="card-text">{{ contact.text }}</p>
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
       ]),
       orderedContacts () {
           console.log(this.all)
           return this.all.sort((a,b) => ((new Date(a.submitedAt) - new Date(b.submitedAt)) * -1))
       }
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
