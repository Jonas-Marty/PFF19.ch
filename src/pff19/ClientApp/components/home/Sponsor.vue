<template>
    <div class="sponsors">
        <div class="container">
            <h2>Sponsoren</h2>
            <div class="sponsor-logos">
                <div 
                    class="sponsor-logo col-md-4"
                    v-for="sponsor in sponsors"
                    :key="sponsor.id"
                >
                    <img :src="require('assets/sponsors/' + sponsor.logo)"  :alt="sponsor.name">
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
                    logo: "logo.png"
                },
                {
                    id: 1,
                    name: "Test Dummy",
                    logo: "logo.png"
                },
                {
                    id: 1,
                    name: "Test Dummy",
                    logo: "logo.png"
                },
                {
                    id: 1,
                    name: "Test Dummy",
                    logo: "logo.png"
                }
            ]
        }
    },
    compputed: {
        
    }

}
</script>

<style lang="scss" scoped>
    .sponsors {
        height: 400px;
        width: 100%;
    }

</style>

