- dbForge Data Compare for MySQL
- SQLBackupAndFTP

- Agregar datos de control a la tabla `xxx`

-phpmyadmin
=> $cfg['ShowBrowseComments'] = false;

START TRANSACTION;
ALTER TABLE `xxx`
ADD `CtrlIdUsuario` VARCHAR(36) NOT NULL COMMENT 'Indica que usuario que realizó el último cambio' AFTER `IdEmpresa`,
ADD `CtrlDireccionIp` VARCHAR(50) NOT NULL COMMENT 'Indica la dirección IP que realizó el último cambio' AFTER `CtrlIdUsuario`,
ADD `CtrlDireccionWeb` TEXT NOT NULL COMMENT 'Indica la dirección web donde se realizó el último cambio' AFTER `CtrlDireccionIp`,
ADD `CtrlCreado` DATETIME NOT NULL COMMENT 'Indica la fecha en la que se creó el registro' AFTER `CtrlDireccionWeb`,
ADD `CtrlModificado` DATETIME NOT NULL COMMENT 'Indica la fecha en la que se modificó el registro' AFTER `CtrlCreado`;
COMMIT;