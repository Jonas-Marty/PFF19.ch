<template>
    <div class="container">
        <h1>Organisation</h1>
        
        <p>
            Das PFF FFS 19 MOSAIK ist die Fortführung einer langjährigen, schweizweiten Tradition – dem Pfadi Folk Fest. 
            Nach der Ausgabe im Sommer 2018 in Liestal findet das PFF im Sommer 2019 im Kanton Zürich statt. Vom 30. 
            August – 01. September 2019  versammeln sich in Stäfa zahlreiche Pfadis und ihre Freunde unter dem Motto «MOSAIK», 
            um ein unvergessliches Festival der etwas anderen Art zu geniessen. 
        </p>
        <p>
            Jeder Teilnehmende bringt als Mosaikstein seine Ecken und Kanten ans PFF FFS 19 MOSAIK mit. Während dem ganzen 
            Festival und den Konzerten bilden sich durch diese vielen verschiedenen anwesenden Mosaiksteinchen immer wieder 
            neue Muster, Formen und Figuren. So erwarten wir im Sommer 2019 unzählig viele verschiedene Mosaikteilchen auf 
            dem Festivalgelände, alle unterschiedlich und einzigartig. Sie vermischen sich, verändern sich gegenseitig und 
            gehen mit neuen Erfahrungen und Eindrücken wieder auseinander.
        </p>
        <div class="team">
            <h2>Das Team</h2>
            <div class="row members">
                <div class="member col-6 col-md-4 col-lg-3" v-for="image in images" :key="image.scoutName">
                    <div class="card">
                        <img class="card-img-top" :src="require(`../assets/images/portraits/${image.scoutName}-min.jpg`)" :alt="image.scoutName">
                        <div class="card-body">
                            <p class="card-text"><b>{{image.scoutName}}</b>, {{image.name}}</p>
                            <p class="card-text">{{image.email}}</p>
                        </div>
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
            images: [
                {   
                    name: "Max Muster",
                    scoutName: 'Aponi',
                    ressort: 'Kommunikation',
                    email: 'info@pff19.ch'
                },
                {
                    name: "Max Muster",
                    scoutName: 'Auriga',
                    ressort: 'Kommunikation',
                    email: 'info@pff19.ch'
                    
                },
                {
                    name: "Max Muster",
                    scoutName: 'Baghira',
                    ressort: 'Kommunikation',
                    email: 'info@pff19.ch'
                },
                {
                    name: "Max Muster",
                    scoutName: 'Bifidus',
                    ressort: 'Kommunikation',
                    email: 'info@pff19.ch'
                },
                {
                    name: "Max Muster",
                    scoutName: 'Dwalin',
                    ressort: 'Kommunikation',
                    email: 'info@pff19.ch'
                },
                {
                    name: "Max Muster",
                    scoutName: 'Fuego',
                    ressort: 'Kommunikation',
                    email: 'info@pff19.ch'
                },
                {
                    name: "Max Muster",
                    scoutName: 'Goofy',
                    ressort: 'Kommunikation',
                    email: 'info@pff19.ch'
                },
                {
                    name: "Max Muster",
                    scoutName: 'Hew',
                    ressort: 'Kommunikation',
                    email: 'info@pff19.ch'
                },
                {
                    name: "Max Muster",
                    scoutName: 'Joya',
                    ressort: 'Kommunikation',
                    email: 'info@pff19.ch'
                },
                {
                    name: "Max Muster",
                    scoutName: 'Karibu',
                    ressort: 'Kommunikation',
                    email: 'info@pff19.ch'
                },
                {
                    name: "Lars Barmettler",
                    scoutName: 'Maimu',
                    ressort: 'Kommunikation',
                    email: 'maimu@pff19.ch'
                },
                {
                    name: "Max Muster",
                    scoutName: 'Martin',
                    ressort: 'Kommunikation',
                    email: 'info@pff19.ch'
                },
                {
                    name: "Max Muster",
                    scoutName: 'Momo',
                    ressort: 'Kommunikation',
                    email: 'info@pff19.ch'
                },
                {
                    name: "Max Muster",
                    scoutName: 'Moneypenny',
                    ressort: 'Kommunikation',
                    email: 'info@pff19.ch'
                },
                {
                    name: "Max Muster",
                    scoutName: 'Orisha',
                    ressort: 'Kommunikation',
                    email: 'info@pff19.ch'
                },
                {
                    name: "Max Muster",
                    scoutName: 'Piccolo',
                    ressort: 'Kommunikation',
                    email: 'info@pff19.ch'
                },
                {
                    name: "Max Muster",
                    scoutName: 'Pipistrella',
                    ressort: 'Kommunikation',
                    email: 'info@pff19.ch'
                },
                {
                    name: "Max Muster",
                    scoutName: 'Pixel',
                    ressort: 'Kommunikation',
                    email: 'info@pff19.ch'
                },
                {
                    name: "Max Muster",
                    scoutName: 'Pluto',
                    ressort: 'Kommunikation',
                    email: 'info@pff19.ch'
                },{
                    name: "Max Muster",
                    scoutName: 'Rajko',
                    ressort: 'Kommunikation',
                    email: 'info@pff19.ch'
                },
                {
                    name: "Max Muster",
                    scoutName: 'Ramon',
                    ressort: 'Kommunikation',
                    email: 'info@pff19.ch'
                },
                {
                    name: "Max Muster",
                    scoutName: 'Snoopy',
                    ressort: 'Kommunikation',
                    email: 'info@pff19.ch'
                },
                {
                    name: "Max Muster",
                    scoutName: 'Soraya',
                    ressort: 'Kommunikation',
                    email: 'info@pff19.ch'
                },
                {
                    name: "Max Muster",
                    scoutName: 'Splash',
                    ressort: 'Kommunikation',
                    email: 'info@pff19.ch'
                },
                {
                    name: "Max Muster",
                    scoutName: 'Strupf',
                    ressort: 'Kommunikation',
                    email: 'info@pff19.ch'
                },
                {
                    name: "Max Muster",
                    scoutName: 'Varuna',
                    ressort: 'Kommunikation',
                    email: 'info@pff19.ch'
                },
                {
                    name: "Max Muster",
                    scoutName: 'Wum',
                    ressort: 'Kommunikation',
                    email: 'info@pff19.ch'
                },
                {
                    name: "Max Muster",
                    scoutName: 'Zirkel',
                    ressort: 'Kommunikation',
                    email: 'info@pff19.ch'
                }
            ]
        }
    }

}
</script>

<style lang="scss" scoped>
    .container {
        padding-top: 100px;
        min-height: 800px;
    }

    .member {
        margin-top: 30px;
    }

    .team {
        margin-top: 50px;
    }

</style>
