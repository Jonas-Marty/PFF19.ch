<template>
    <div class="goenner col-12 col-md-4">
        <a :href="sponsor.link">
            <div class="goenner-text">
               {{ sponsor.name }}
            </div>
        </a>
    </div>
</template>

<script>
import axios from 'axios'
import { mapActions, mapGetters } from 'vuex'

export default {
    props: ['sponsor'],

}
</script>

<style lang="scss" scoped>
    .sponsor {
        padding: 5px;
    }


</style>

