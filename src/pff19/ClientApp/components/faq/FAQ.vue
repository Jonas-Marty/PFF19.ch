<template>
<div>
    <faq-fr v-if="language === 'fr'"></faq-fr>
    <faq-de v-else></faq-de>
</div>
</template>

<script> 
import { mapGetters } from 'vuex'
import faqDe from './FAQDE'
import faqFr from './FAQFR'
export default {
    components: {
        faqDe,
        faqFr
    },

    computed: {
        ...mapGetters([
            'language'
        ])
    }

}
</script>

