<template>
    <div class="sponsors container">
        <h2>{{ $t('lang.components.home.sponsors.sponsors') }}</h2>
        
        <div class="row">
            <div class="sponsor col-md-4"
                v-for="sponsor in sponsors"
                :key="sponsor.id"
            >   
                <div class="card">
                    <div class="card-body">
                        <a :href="sponsor.link">
                        <img :src="require('assets/sponsors/' + sponsor.logo)">
                        </a>
                    </div> 
                </div> 
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';

export default {
    data () {
        return {
            sponsors: []
        }
    },

    created() {
        axios.get('/api/sponsors')
        .then(response => {
            this.sponsors = response.data;
        }).catch(e => {
            this.errors.push(e)
        });
    }

}
</script>

<style lang="scss" scoped>
    .sponsors {
        width: 100%;
        margin-top: 20px;
    }

    .sponsor {
        margin-bottom: 20px;
    }

    .sponsors img {
        width: 100%;
    }

</style>

