

function ModalToggle(idModal) {
    console.log($(`#${idModal}`));
    $(`#${idModal}`).modal('toggle');
}
function CloseAllModals() {

   $('.modal.fade.show').modal('hide')

}
function ModalEstatica(idModal) {
    $(`#${idModal}`).modal({ backdrop: 'static', keyboard: false })  
 }

function MostrarNotificacionCarrito() {
    var notificacion = document.querySelector(".eCommerce .carritoCompras .notificacion");
    console.log(notificacion);
    notificacion.classList.add("show");
    setTimeout(()=>{notificacion.classList.remove("show")}, 5000);

}
function goToLandingPage() {
    const $element = document.querySelector('#landingPage');
    $element.scrollIntoView({ behavior: 'smooth' })
}
function goToTienda() {
    const $element = document.querySelector('#tienda');
    $element.scrollIntoView({ behavior: 'smooth' })
}

function alerta(posicion, icono, mensaje) {
    Swal.fire({
        position: posicion,
        icon: icono,
        title: mensaje,
        showConfirmButton: true,
        //timer: 1500
    })
}

function saveAsFile(filename, bytesBase64) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/octet-stream;base64," + bytesBase64;
    document.body.appendChild(link); // Needed for Firefox
    link.click();
    document.body.removeChild(link);
}
function saveAsFile(filename, bytesBase64) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/octet-stream;base64," + bytesBase64;
    document.body.appendChild(link); // Needed for Firefox
    link.click();
    document.body.removeChild(link);
}


function initMap(coords, mapaId) {
    // Map options

  
    try {
        var options = {
            zoom: 15,
            center: { lat: coords.lat, lng: coords.lng }
        }
        // New map
        var map = new google.maps.Map(document.getElementById(mapaId), options);
        addMarker({ coords: coords });

        // Listen for click on map
        //google.maps.event.addListener(map, 'click', function (event) {
        //    // Add marker
        //    addMarker({ coords: event.latLng });
        //});

        /*
        // Add marker
        var marker = new google.maps.Marker({
          position:{lat:42.4668,lng:-70.9495},
          map:map,
          icon:'https://developers.google.com/maps/documentation/javascript/examples/full/images/beachflag.png'
        });
    
        var infoWindow = new google.maps.InfoWindow({
          content:'<h2>Lynn MA</h2>'
        });
    
        marker.addListener('click', function(){
          infoWindow.open(map, marker);
        });
        */

        // Array of markers
        var markers = [
            {
                coords: { lat: 42.4668, lng: -70.9495 },
                iconImage: 'https://developers.google.com/maps/documentation/javascript/examples/full/images/beachflag.png',
                content: '<h2>Lynn MA</h2>'
            },
            {
                coords: { lat: 42.8584, lng: -70.9300 },
                content: '<h2>Amesbury MA</h2>'
            },
            {
                coords: { lat: 42.7762, lng: -71.0773 }
            }
        ];

        // Loop through markers
        for (var i = 0; i < markers.length; i++) {
            // Add marker
            addMarker(markers[i]);
        }

        // Add Marker Function
        function addMarker(props) {
            var marker = new google.maps.Marker({
                position: props.coords,
                map: map,
                //icon:props.iconImage
            });

            // Check for customicon
            if (props.iconImage) {
                // Set icon image
                marker.setIcon(props.iconImage);
            }

            // Check content
            if (props.content) {
                var infoWindow = new google.maps.InfoWindow({
                    content: props.content
                });

                marker.addListener('click', function () {
                    infoWindow.open(map, marker);
                });
            }
        }

    } catch (e) {

    }
  
}

async function buscarCoordenadas(direccion, idMapa) {
    console.log(direccion);
    var response = await fetch(`https://maps.googleapis.com/maps/api/geocode/json?address=${direccion}+View,+CA&key=AIzaSyBcY4My1g3o1kKz24IdrzTEvOR863ihV7U`);
    direccion = await response.json();
    initMap(direccion.results[0].geometry.location, idMapa);
    return [direccion.results[0].geometry.location.lat, direccion.results[0].geometry.location.lng];
}

function initSlider() {
    var swiper = new Swiper('.swiper-container', {
        pagination: {
            el: '.swiper-pagination',
            type: 'progressbar',

        },
        navigation: {
            nextEl: '.swiper-button-next',
            prevEl: '.swiper-button-prev',
        },
        //navigation: {
        //    nextEl: '.btnSiguiente',
        //    prevEl: '.btnAnterior',
        //},
    });

    var swiper1 = new Swiper('.swiper-container.banner', {
        autoplay: {
            delay: 4000,
        },
        pagination: {
            el: '.swiper-pagination',
            
        },
    });
}
const callback = function (entries, observer) {
    const $logo = document.querySelector(".eCommerce .tienda .navBar .logoTienda img");
    if (entries[0].isIntersecting) {
        $logo.classList.remove("small");


    } else {

        $logo.classList.add("small");

    }
   


};
function intersectionObserver() {

    var options = {
        root: document.querySelector('#scrollArea'),
        rootMargin: '0px',
        threshold: 0
    }
    const $banner = document.querySelector(".eCommerce .banner");
    console.log($banner);
    var observer = new IntersectionObserver(callback, options);

    observer.observe($banner);

}


const callbackInfinite = function (dotnetHelper,entries, observer) {
    
};
function InfiniteScroll(dotnetHelper) {
    console.log(dotnetHelper)
    var options = {
        root: document.querySelector('#scrollArea'),
        rootMargin: '0px',
        threshold: 1
    }
    const $ultimoProducto = document.querySelector(".eCommerce .ultimoProducto");
    console.log($ultimoProducto);


    var observer = new IntersectionObserver((entries, observer) => {
        console.log("entre en callbackInfinite")
        if (entries[0].isIntersecting) {
            console.log("estoy interceptando");
            dotnetHelper.invokeMethodAsync("infiniteScroll");

        } else {
            console.log("no estoy interceptando");


        }

    }, options);

    observer.observe($ultimoProducto);

}

function graficoVendedores(data, id) {
    console.log(data);
    am4core.useTheme(am4themes_animated);
    // Themes end

    var chart = am4core.create(id, am4charts.PieChart3D);
    chart.hiddenState.properties.opacity = 0; // this creates initial fade-in

    chart.data = data;

    chart.innerRadius = am4core.percent(30);
    chart.depth = 10;

    chart.legend = new am4charts.Legend();

    var series = chart.series.push(new am4charts.PieSeries3D());
    series.dataFields.value = "total";
    series.dataFields.depthValue = "total";
    series.dataFields.category = "vendedor";
    series.slices.template.cornerRadius = 3;
    series.colors.step = 5;
}

function ventasPorZona(data, id) {
    var chart = am4core.create(id, am4charts.XYChart);
    console.log(data)
    const separarProvincias = function (array) { return [...new Set(array.map(y => y.provincia))]; }
    const provinciasDistinc = separarProvincias(data);
    // Add data
    chart.data = data;

    // Create axes
    var yAxis = chart.yAxes.push(new am4charts.CategoryAxis());
    yAxis.dataFields.category = "localidad";
    yAxis.renderer.grid.template.location = 0;
    yAxis.renderer.labels.template.fontSize = 10;
    yAxis.renderer.minGridDistance = 10;

    var xAxis = chart.xAxes.push(new am4charts.ValueAxis());

    // Create series
    var series = chart.series.push(new am4charts.ColumnSeries());
    series.dataFields.valueX = "total";
    series.dataFields.categoryY = "localidad";
    series.columns.template.tooltipText = "{categoryY}: [bold]{valueX}[/]";
    series.columns.template.strokeWidth = 0;
    series.columns.template.adapter.add("fill", function (fill, target) {
        if (target.dataItem) {
            switch (target.dataItem.dataContext.provincia) {
                case "Mendoza":
                    return chart.colors.getIndex(3);
                    break;
                case "Buenos Aires":
                    return chart.colors.getIndex(1);
                    break;
                case "San Luis":
                    return chart.colors.getIndex(2);
                    break;
             
            }
        }
        return fill;
    });

    var axisBreaks = {};
    var legendData = [];

    // Add ranges
    function addRange(label, start, end, color) {
        var range = yAxis.axisRanges.create();
        range.category = start;
        range.endCategory = end;
        range.label.text = label;
        range.label.disabled = false;
        range.label.fill = color;
        range.label.location = 0;
        range.label.dx = -80;
        range.label.dy = 12;
        range.label.fontWeight = "bold";
        range.label.fontSize = 12;
        range.label.horizontalCenter = "left"
        range.label.inside = true;

        range.grid.stroke = am4core.color("#396478");
        range.grid.strokeOpacity = 1;
        range.tick.length = 200;
        range.tick.disabled = false;
        range.tick.strokeOpacity = 0.6;
        range.tick.stroke = am4core.color("#396478");
        range.tick.location = 0;

        range.locations.category = 1;
        var axisBreak = yAxis.axisBreaks.create();
        axisBreak.startCategory = start;
        axisBreak.endCategory = end;
        axisBreak.breakSize = 1;
        axisBreak.fillShape.disabled = true;
        axisBreak.startLine.disabled = true;
        axisBreak.endLine.disabled = true;
        axisBreaks[label] = axisBreak;

        legendData.push({ name: label, fill: color });
    }
    for (let i = 0; i < provinciasDistinc.length; i++) {
        const provincia = provinciasDistinc[i];
        const localidadInicial = data.find(x => x.provincia === provincia).localidad;
        let contador = 0;
        data.map(x => { if (x.provincia === provincia) { contador++; } });

        const posicionLocalidadInicial = data.indexOf(data.find(x => x.provincia === provincia));


        console.log("Posicion De la Primera " + posicionLocalidadInicial + " CantidadDe Registros: " + contador)

        const localidadFinal = data[posicionLocalidadInicial + (contador == 0 ? contador : contador-1)].localidad;
        console.log(provincia + localidadInicial + localidadFinal);

        console.log(localidadFinal);
        addRange(provincia, localidadFinal , localidadInicial, chart.colors.getIndex(i));

    }


    
   

    chart.cursor = new am4charts.XYCursor();


    var legend = new am4charts.Legend();
    legend.position = "bottom";
    legend.scrollable = true;
    legend.valign = "top";
    legend.reverseOrder = true;

    chart.legend = legend;
    legend.data = legendData;

    legend.itemContainers.template.events.on("toggled", function (event) {
        var name = event.target.dataItem.dataContext.name;
        var axisBreak = axisBreaks[name];
        if (event.target.isActive) {
            axisBreak.animate({ property: "breakSize", to: 0 }, 1000, am4core.ease.cubicOut);
            yAxis.dataItems.each(function (dataItem) {
                if (dataItem.dataContext.provincia == name) {
                    dataItem.hide(1000, 500);
                }
            })
            series.dataItems.each(function (dataItem) {
                if (dataItem.dataContext.provincia == name) {
                    dataItem.hide(1000, 0, 0, ["valueX"]);
                }
            })
        }
        else {
            axisBreak.animate({ property: "breakSize", to: 1 }, 1000, am4core.ease.cubicOut);
            yAxis.dataItems.each(function (dataItem) {
                if (dataItem.dataContext.provincia == name) {
                    dataItem.show(1000);
                }
            })

            series.dataItems.each(function (dataItem) {
                if (dataItem.dataContext.provincia == name) {
                    dataItem.show(1000, 0, ["valueX"]);
                }
            })
        }
    })

}

function graficoGananciaPorListaPrecios(data, id) {
    console.log(data);

    am4core.useTheme(am4themes_animated);
    // Themes end

    // Create chart instance
    var chart = am4core.create(id, am4charts.XYChart);

    //

    // Increase contrast by taking evey second color
    chart.colors.step = 2;

    // Add data
    chart.data = generateChartData();
    // Create axes
    var dateAxis = chart.xAxes.push(new am4charts.DateAxis());
    dateAxis.renderer.minGridDistance = 50;

    // Create series
    function createAxisAndSeries(field, name, opposite, bullet) {
        var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
        if (chart.yAxes.indexOf(valueAxis) != 0) {
            valueAxis.syncWithAxis = chart.yAxes.getIndex(0);
        }

        var series = chart.series.push(new am4charts.LineSeries());
        series.dataFields.valueY = field;
        series.dataFields.dateX = "date";
        series.strokeWidth = 2;
        series.yAxis = valueAxis;
        series.name = name;
        series.tooltipText = "{name}: [bold]{valueY}[/]";
        series.tensionX = 0.8;
        series.showOnInit = true;

        var interfaceColors = new am4core.InterfaceColorSet();

        switch (bullet) {
            case "triangle":
                var bullet = series.bullets.push(new am4charts.Bullet());
                bullet.width = 12;
                bullet.height = 12;
                bullet.horizontalCenter = "middle";
                bullet.verticalCenter = "middle";

                var triangle = bullet.createChild(am4core.Triangle);
                triangle.stroke = interfaceColors.getFor("background");
                triangle.strokeWidth = 2;
                triangle.direction = "top";
                triangle.width = 12;
                triangle.height = 12;
                break;
            case "rectangle":
                var bullet = series.bullets.push(new am4charts.Bullet());
                bullet.width = 10;
                bullet.height = 10;
                bullet.horizontalCenter = "middle";
                bullet.verticalCenter = "middle";

                var rectangle = bullet.createChild(am4core.Rectangle);
                rectangle.stroke = interfaceColors.getFor("background");
                rectangle.strokeWidth = 2;
                rectangle.width = 10;
                rectangle.height = 10;
                break;
            default:
                var bullet = series.bullets.push(new am4charts.CircleBullet());
                bullet.circle.stroke = interfaceColors.getFor("background");
                bullet.circle.strokeWidth = 2;
                break;
        }

        valueAxis.renderer.line.strokeOpacity = 1;
        valueAxis.renderer.line.strokeWidth = 2;
        valueAxis.renderer.line.stroke = series.stroke;
        valueAxis.renderer.labels.template.fill = series.stroke;
        valueAxis.renderer.opposite = opposite;
    }
    let cantidadListas = data[0].valores.length;

    if (data.length > 0) {
        for (let i = 0; i < cantidadListas; i++) {
            console.log(data[0].valores[i].nombreLista);
            createAxisAndSeries(data[0].valores[i].nombreLista, data[0].valores[i].nombreLista, true, "circle");
        }
    }
    
  

    // Add legend
    chart.legend = new am4charts.Legend();

    // Add cursor
    chart.cursor = new am4charts.XYCursor();

    // generate some random data, quite different range
    function generateChartData() {
     
        var chartData = [];

        for (let i = 0; i < data.length; i++) {

            let valoresDelDia = {
                date: data[i].fecha
            }

            for (let j = 0; j < data[0].valores.length ; j++) {
               
                let nombre = data[i].valores[j].nombreLista;
                let importe = data[i].valores[j].importe;

               
                Object.defineProperty(valoresDelDia, nombre, {value:importe});

            }
        
            
            chartData.push(valoresDelDia);
        }
        console.log(chartData);

        return chartData;
    }

}; 






function gananciasPorLista(data, id) {
am4core.useTheme(am4themes_animated);
// Themes end

var chart = am4core.create(id, am4charts.PieChart3D);
chart.hiddenState.properties.opacity = 0; // this creates initial fade-in

chart.legend = new am4charts.Legend();

chart.data = data;

var series = chart.series.push(new am4charts.PieSeries3D());
series.dataFields.value = "total";
series.dataFields.category = "lista";

}
