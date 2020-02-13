create database abarrotespueblito;
use abarrotespueblito;
show tables;
create table provedor(idprovedor int auto_increment primary key,
nombrep varchar(50),
direccion varchar(30),
telefono varchar(15));

create table suministro(idsuministro int auto_increment primary key,
cantidad int,
fecha varchar(15),
fkproducto int,
fkprovedor int,
foreign key(fkproducto) references productos(idproducto),
foreign key(fkprovedor) references provedor(idprovedor));

create table productos(idproducto int auto_increment primary key,
nombreproducto varchar(30),
precio double,
fkcategoria int,
foreign key(fkcategoria) references categoria(idcategoria));

create table categoria(idcategoria int auto_increment primary key,
nombre varchar(30));

drop view v_provedor;
create view v_provedor as
select nombrep as 'Nombre_del_provedor',
nombreproducto as 'Nombre_del_producto',
cantidad as 'Cantidad',precio as 'Precio_del_producto',fecha as 'Fecha_de_venta',categoria.nombre as'Categoria' from provedor,productos,suministro,categoria where suministro.fkproducto = productos.idproducto and
suministro.fkprovedor = provedor.idprovedor and productos.fkcategoria = categoria.idcategoria;
insert into provedor values(null,'juan','josefina','445444');
insert into categoria values(null,'reefresco');
insert into productos values(null,'cocacola',7,1);
insert into suministro values(null,10,'02-06-1999',1,1);
insert into provedor values(null,'pablo','la loma','4745645534');
insert into categoria values(null,'pan');
insert into productos values(null,'concha',5,2);
insert into suministro values(null,50,'12-02-2020',2,2);
select * from v_provedor;

create procedure p_suministro(in _cantidad int,_fecha varchar(15),_fkproducto int,_fkprovedor int,out _mensaje varchar(15))
begin 
if _cantidad > 0
then
insert into suministro values(null,_cantidad,_fecha,_fkproducto,_fkprovedor);
else
select 'el campo de cantidad esta vacio' into _mensaje;
end if;
end ;

select * from v_provedor order by Categoria asc;