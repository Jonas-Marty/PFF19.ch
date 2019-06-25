<template>
  <div class="container-fluid">
    <app-polygon color="green" position="left"></app-polygon>
    <div class="container faq">
      <div class="offset-lg-1 col-lg-10">
        <h1>FAQ's</h1>

        <h3>C’est quoi un FFS?</h3>
        <p>
          Le PFF FFS 19 MOSAIK est la continuation d’une longue tradition suisse – de la Fête Folk
          Scoute (FFS). Après l’édition
          <a href="https://www.pff18.ch/">2018 à Liestal</a>, le FFS a lieu en été au canton Zurich.
          Du 30.08 au 01.09.2019, nombreux scouts et leurs amis regroupent à Stäfa sous le signe de
          «MOSAÏQUE » pour profiter d’un festival inoubliable.
        </p>

        <h3>Un moment … «MOSAÏQUE » ?</h3>
        <p>
          Chaque participant contribue comme une pièce de mosaïque au PFF FFS 19 MOSAIK. Pendant
          tous le festival et tous les concerts des motifs, formes et figures se forment avec les
          pièces de mosaïque présentes et diverses. Nous nous attendons des pièces de mosaïque
          innombrables en été 2019 sur le domaine du festival – toutes diverses et uniques. Elles se
          mélangent, se changent mutuellement et se dispersent avec des expériences et des
          impressions nouveaux. Tout comme il est courant avec les scouts.
        </p>

        <h3>Tickets</h3>
        <p>
          La prévente sera lancée en janvier 2019. Sois le premier à apprendre de la prévente et
          augmentes tes chances pour un des early-bird-tickets limités et très demandés.
        </p>

        <h3>Bénévolat</h3>
        <p>
          Pas assez d’argent pour le ticket? Viens comme bénévole au FFS !<br />

          Inscris-toi comme bénévole maintenant
          <router-link :to="{ name: 'helper' }">ici</router-link>
          pour avoir la possibilité de choisir ton poste de travail aussitôt que l’horaire est
          online.
        </p>

        <h3>Sponsors</h3>
        <p>
          Un évènement si grand comme le FFS ne peut pas joindre les deux bouts sans soutien
          financier. Si tu veux nous soutenir, apporter ta collaboration ou si tu as une offre de
          sponsoring matériel, mets-toi en contact avec notre sponsoring équipe directement :
          <a href="mailto:sponsoring@pff19.ch">sponsoring@pff19.ch</a><br /><br />

          Le comité et 47‘000 scouts te remercient déjà pour ton soutien!
        </p>

        <h3>Bands</h3>
        <p>
          Malgré les rumeurs – le line-up n’est pas encore annoncé. Sitôt que nous avons une
          nouvelle, nous les annoncerons via
          <a
            href="https://pff2019.us12.list-manage.com/subscribe/post?u=49efe2269ccc4a7227ef08f59&id=067179a941"
            >Newsletter</a
          >, auf <a href="https://www.facebook.com/pff19mosaik/">Facebook</a> et
          <a href="https://www.instagram.com/pff_19_mosaik/">Instagram</a><br /><br />

          Le FFS offre la scène optimale pour des groupes petits mais raffiné. Si tu veux poser ta
          candidature avec ta band comme « groupe scoute », mets-toi en contact avec
          <a href="mailto:bands@pff19.ch">bands@pff19.ch</a>
        </p>

        <div class="col">
          <div class="row">
            <router-link :to="{ name: 'contact' }">
              <div class="btn btn-primary">autres questions</div>
            </router-link>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {}
</script>

<style lang="scss" scoped>
.faq {
  position: relavtive;
}
.container {
  padding-top: 100px;
}

h3 {
  margin-top: 40px;
}

.row {
  margin-top: 40px;
}
</style>
