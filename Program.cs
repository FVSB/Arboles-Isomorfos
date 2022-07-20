

var uno = new BinarianTree<int>(1);
var dos = new BinarianTree<int>(2);
var tres = new BinarianTree<int>(3);
var cuatro = new BinarianTree<int>(4);
var cinco = new BinarianTree<int>(5);
var seis = new BinarianTree<int>(6);
var siete = new BinarianTree<int>(7);
var ocho = new BinarianTree<int>(8);
var nueve = new BinarianTree<int>(9);
var diez = new BinarianTree<int>(10);


cuatro.AddChild(nueve, true);
cuatro.AddChild(ocho, false);

cinco.AddChild(diez, false);

dos.AddChild(cuatro, false);
dos.AddChild(cinco, true);

tres.AddChild(seis, false);
tres.AddChild(siete, true);

uno.AddChild(dos, false);
uno.AddChild(tres, true);




var unol = new BinarianTree<int>(1);
var dosl = new BinarianTree<int>(2);
var tresl = new BinarianTree<int>(3);
var cuatrol = new BinarianTree<int>(4);
var cincol = new BinarianTree<int>(5);
var seisl = new BinarianTree<int>(6);
var sietel = new BinarianTree<int>(7);
var ochol = new BinarianTree<int>(8);
var nuevel = new BinarianTree<int>(9);
var diezl = new BinarianTree<int>(10);




cuatrol.AddChild(nuevel, false);
cuatrol.AddChild(ochol, true);

cincol.AddChild(diezl, true);

dosl.AddChild(cuatrol, false);
dosl.AddChild(cincol, true);

tresl.AddChild(seisl, true);
tresl.AddChild(sietel, false);

unol.AddChild(dosl, true);
unol.AddChild(tresl, false);



System.Console.WriteLine(ArbolesIsomorfos.Binarios(uno, unol));