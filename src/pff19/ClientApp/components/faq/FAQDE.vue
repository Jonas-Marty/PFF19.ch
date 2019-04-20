<template>
    <div class="container-fluid">
        <app-polygon color="green" position="left"></app-polygon>
        <div class="container faq">
            <div class="offset-lg-1 col-lg-10">
                <h1>FAQ's</h1>

                <h3>Was ist ein PFF?</h3>
                <p>
                    Das PFF FFS 19 MOSAIK ist die Fortführung einer langjährigen, schweizweiten
                    Tradition – dem Pfadi Folk Fest. Nach der
                    <a href="https://www.pff18.ch/">Ausgabe im Sommer 2018 in Liestal</a> findet das
                    PFF im Sommer 2019 im Kanton Zürich statt. Vom 30. August – 01. September 2019
                    versammeln sich in Stäfa zahlreiche Pfadis und ihre Freunde unter dem Motto
                    «MOSAIK», um ein unvergessliches Festival der etwas anderen Art zu geniessen.
                </p>

                <h3>Moment… «MOSAIK»?</h3>
                <p>
                    Jeder Teilnehmende bringt als Mosaikstein seine Ecken und Kanten ans PFF FFS 19
                    MOSAIK mit. Während dem ganzen Festival und den Konzerten bilden sich durch
                    diese vielen verschiedenen anwesenden Mosaiksteinchen immer wieder neue Muster,
                    Formen und Figuren. So erwarten wir im Sommer 2019 unzählig viele verschiedene
                    Mosaikteilchen auf dem Festgelände, alle unterschiedlich und einzigartig. Sie
                    vermischen sich, verändern sich gegenseitig und gehen mit neuen Erfahrungen und
                    Eindrücken wieder auseinander. Ganz so, wie es in der Pfadi üblich ist.
                </p>

                <h3>Tickets</h3>
                <p>
                    Der Ticketvorverkauf startet im Januar 2019. Erfahre als Erster vom
                    Vorverkaufsstart und erhöhe deine Chance auf ein heissbegehrtes und limitiertes
                    Early-Bird-Ticket: Jetzt in
                    <a
                        href="https://pff2019.us12.list-manage.com/subscribe/post?u=49efe2269ccc4a7227ef08f59&id=067179a941"
                        >Newsletter</a
                    >
                    eintragen
                </p>

                <h3>Helfer</h3>
                <p>
                    Nicht genügend Geld für´s Ticket? Komm doch als Helfer ans PFF! Schreibe dich
                    jetzt <router-link :to="{ name: 'helper' }">hier</router-link> als Helfer ein,
                    um als Erste/r aus den Schichten auswählen zu können, sobald diese aufgeschaltet
                    werden.
                </p>

                <h3>Sponsoren</h3>
                <p>
                    Ein Grossanlass wie das PFF kommt trotz unzähligen Freiwilligenstunden nicht
                    ohne finanzielle Unterstützung aus. Falls Du uns unterstützen, eine
                    Partnerschaft mit uns eingehen möchtest oder ein Angebot für ein
                    «Sachsponsoring» hast, melde Dich mit Deiner Anfrage direkt bei
                    <a href="mailto:sponsoring@pff19.ch">sponsoring@pff19.ch</a>
                </p>

                <p>
                    Das OK und 47´000 Pfadis aus der ganzen Schweiz danken Dir bereits jetzt für
                    Deine Unterstützung!
                </p>

                <h3>Bands</h3>
                <p>
                    Auch wenn bereits Gerüchte kursieren, ist das Line-Up noch nicht bekannt. Sobald
                    wir Neuigkeiten haben, werden wir sie via
                    <a
                        href="https://pff2019.us12.list-manage.com/subscribe/post?u=49efe2269ccc4a7227ef08f59&id=067179a941"
                        >Newsletter</a
                    >, auf <a href="https://www.facebook.com/pff19mosaik/">Facebook</a> und
                    <a href="https://www.instagram.com/pff_19_mosaik/">Instagram</a> bekanntgeben.
                </p>

                <p>
                    Das PFF bietet die optimale Bühne für kleine, aber feine Bands. Falls du dich
                    mit deiner Band als «Pfadiband» bewerben möchtest, melde dich direkt bei
                    <a href="mailto:bands@pff19.ch">bands@pff19.ch</a>
                </p>

                <div class="col">
                    <div class="row">
                        <router-link :to="{ name: 'contact' }">
                            <div class="btn btn-primary">Andere Fragen</div>
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
