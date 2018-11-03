<template>
    <div>
        <h1>Kontaktanfragen</h1>
        <div class="row">
            <div class="col-12 col-md-4"  v-for="contact in all" :key="contact.id">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">
                            {{ contact.firstName }}, {{ contact.lastName }}
                        </h5>
                        <h6 class="card-subtitle mb-2 text-muted">{{ contact.mail }}</h6>
                        <p class="card-text">{{ contact.text }}</p>
                    </div>
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
