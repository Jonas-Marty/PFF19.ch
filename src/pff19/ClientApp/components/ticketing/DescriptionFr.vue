<template>
    <div class="container">
        <div class="ticket-buying card row">
            <h1 class="title">Deviens part de notre mosaïque avec ton ticket!</h1>

            <div class="alert alert-info helfer">
                <h3>Bénévoles</h3>
                <p>
                    Est-ce que tu voudrais soutenir le FFS comme bénévole et ainsi profiter d’un
                    avantage sur ton ticket?
                    <a href="https://pff19.ukula.ch/" target="_blank">Deviens bénévole!</a> (Les
                    bénévoles reçoivent leurs tickets réduits directement à la caisse quand ils
                    arrivent et ils ne doivent pas acheter un ticket en prévente!)
                </p>
            </div>

            <div class="col-md-6 offset-md-3 iframe-wrapper">
                <iframe
                    class="iframe"
                    datasrc="https://www.ticketino.com/fr/Event/Embed/80740"
                    frameborder="0"
                    src="https://www.ticketino.com/fr/Event/Embed/80740"
                >
                </iframe>
            </div>
        </div>

        <div class="alert">
            <h3>Informations</h3>
            <ul>
                <li>
                    Quand tu achètes un ticket de trois jours avant le <b>31. mai</b>, tu reçois une
                    réduction de <b>50%</b> pour ton ticket de CFF pour aller et retour en train
                    (CFF code de réduction).
                </li>

                <li>
                    Il est possible d’acheter un ticket (pour une personne) le dimanche à la caisse.
                </li>

                <li>
                    <b>Le ticket de familles</b> contient l’entrée pour une famille (2 adultes +
                    leurs enfants jusqu’à l’âge 16). Il n’est pas possible d’acheter d’autres
                    tickets pour le dimanche en prévente. Enfants de moins de 6 ans sont
                    <b>gratuits</b>.
                </li>

                <li>
                    Le FFS est pour les visiteurs à partir de 16 ans (sauf le dimanche de familles).
                </li>

                <li>
                    Attention: Les bouteilles de verre sont interdites au terrain du festival et à
                    l’emplacement de tentes.
                </li>

                <li>
                    L’alcool distillé est interdit au festival entier. Il n’est pas toléré et il
                    sera confisqué.
                </li>

                <li>
                    Avec l'achat d'un ticket ou avec l'inscription comme bénévole tu acceptes nos
                    <a href="/assets/AGB PFF Stäfa 2019 Besucher.pdf" target="_blank"
                        >conditions générales</a
                    >
                </li>

                <li>
                    Les règles du festival ont cours pendant tout le festival, voir les règles du
                    festival dans le programme au check-in.
                </li>
            </ul>
            <p>
                Est-ce que tu as des questions au sujet des tickets ou du festival? Tu trouveras
                certainement les réponses <router-link :to="{ name: 'faq' }">ici</router-link>.
            </p>
            <p>
                Est-ce que tu as de problèmes techniques avec l’achat de tickets ou avec le
                processus de paiement? Nous sommes à ton disposition pour t’aider sous
                <a href="mailto:ticket@pff19.ch">ticket@pff19.ch</a>
            </p>
        </div>

        <div class="row">
            <div class="col-12 col-md-4">
                <div class="card">
                    <img
                        class="card-img-top"
                        src="../../assets/images/3_tages_pass.jpg"
                        alt="Card image cap"
                    />
                    <div class="card-body">
                        <h5 class="card-title">Ticket de 3 jours</h5>
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item">
                                Entrée au terrain du festival et à l’emplacement de tentes du
                                vendredi au dimanche
                            </li>
                            <li class="list-group-item">Goodie-bag incl. 1x gobelet de festival</li>
                            <li class="list-group-item">
                                Ravitaillement : 2x dîner, 2x petit-déjeuner. S’il te plaît amène ta
                                propre vaisselle pour manger.
                            </li>
                            <li class="list-group-item">
                                Navette de la gare Stäfa au terrain du festival
                            </li>
                            <li class="list-group-item">
                                Voyage au prix réduit avec le CFF quand tu achètes un ticket avant
                                le 31. mai 2019
                            </li>
                        </ul>
                    </div>
                </div>
            </div>

            <div class="col-12 col-md-4">
                <div class="card">
                    <img
                        class="card-img-top"
                        src="../../assets/images/1_tagesticket.jpg"
                        alt="Card image cap"
                    />
                    <div class="card-body">
                        <h5 class="card-title">Ticket pour 1 jour vendredi ou samedi</h5>
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item">
                                Entrée au terrain du festival au jour respectif
                            </li>
                            <li class="list-group-item">1x gobelet de festival</li>
                            <li class="list-group-item">
                                Ravitaillement : 1x dîner. S’il te plaît amène ta propre vaisselle
                                pour manger.
                            </li>
                            <li class="list-group-item">
                                Navette de la gare Stäfa au terrain du festival
                            </li>
                        </ul>
                    </div>
                </div>
            </div>

            <div class="col-12 col-md-4">
                <div class="card">
                    <img
                        class="card-img-top"
                        src="../../assets/images/kinder_sonntag.jpg"
                        alt="Card image cap"
                    />
                    <div class="card-body">
                        <h5 class="card-title">Ticket de famille dimanche</h5>
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item">
                                Entrée au terrain du festival au dimanche pour la famille (2 adultes
                                + leurs enfants jusqu’à l’âge 16) et participation au programme pour
                                les enfants
                            </li>
                            <li class="list-group-item">2x gobelets de festival</li>
                            <li class="list-group-item">
                                Navette de la gare Stäfa au terrain du festival
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>

        <app-polygon color="yellow" position="left"> </app-polygon>
    </div>
</template>

<style lang="scss" scoped>
.ticket-buying {
    margin-top: -250px;
    min-height: 800px;
    z-index: 2;
    position: relative;
}

.card {
    margin-bottom: 30px;
}

.title {
    width: 80%;
    margin: auto;
    margin-bottom: 50px;
    margin-top: 50px;
}
.card-img-top {
    padding: 0;
}

.iframe-wrapper {
    margin-bottom: 30px;
}

.iframe {
    width: 100%;
    height: 400px;
}

.helfer {
    width: 80%;
    margin: 0 auto;
    margin-bottom: 50px;
}
</style>
