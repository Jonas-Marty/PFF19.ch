<template>
  <div>
    <h1>Sponsoren</h1>
    <router-link to="sponsoring/add">
      <i class="fa fa-add fa-1x pull-right"></i>hinzufügen
    </router-link>
    <div class="list-group">
      <div
        v-for="sponsor in all"
        :key="sponsor.id"
        class="list-group-item d-flex justify-content-between"
      >
        <div>
          {{ status[sponsor.status] }}
          <b>{{ sponsor.name }}</b>
        </div>
        <div>
          <i @click="remove(sponsor.id)" class="fa fa-remove fa-1x pull-right"></i>
          <router-link :to="{ name: 'adminSponsoringEdit', params: { id: sponsor.id } }">
            <i class="fa fa-edit fa-1x pull-right"></i>
          </router-link>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { mapActions, mapGetters } from 'vuex'

export default {
  data() {
    return {
      status: {
        0: 'Hauptsponsor',
        1: 'Co-Sponsor',
        2: 'Partner',
        3: 'Gönner (Privatperson)',
        4: 'Infrastrukturpartner',
        5: 'Pfadi-Partner',
        6: 'Gönner (Unternehmen)'
      }
    }
  },

  computed: {
    ...mapGetters('sponsors', ['all', 'mainSponsors'])
  },

  created() {
    this.load()
  },

  methods: {
    ...mapActions('sponsors', ['load', 'remove'])
  }
}
</script>

<style lang="scss" scoped>
.fa-remove {
  cursor: pointer;
}

.fa-edit {
  margin-right: 5px;
}
</style>
