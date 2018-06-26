<template>
    <div class="sponsors container">
        <h2>Sponsoren</h2>
        
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
export default {
    data () {
        return {
            sponsors: [
                {
                    id: 1,
                    name: "Test Dummy",
                    logo: "logo.png",
                    link: "https://vuejs.org/"
                },
                {
                    id: 2,
                    name: "Test sdfDummy",
                    logo: "logo.png",
                    link: "https://vuejs.org/"
                },
                {
                    id: 3,
                    name: "Test Daummy",
                    logo: "logo.png",
                    link: "https://vuejs.org/"
                },
                {
                    id: 4,
                    name: "Test Dumasdfmy",
                    logo: "logo.png",
                    link: "https://vuejs.org/"
                }
            ]
        }
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

