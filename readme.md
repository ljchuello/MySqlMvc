- dbForge Data Compare for MySQL
- SQLBackupAndFTP

- Agregar datos de control a la tabla `xxx`

-phpmyadmin
=> $cfg['ShowBrowseComments'] = false;

START TRANSACTION;
ALTER TABLE `xxx`
ADD `CtrlIdUsuario` VARCHAR(36) NOT NULL COMMENT 'Indica que usuario que realiz� el �ltimo cambio' AFTER `IdEmpresa`,
ADD `CtrlDireccionIp` VARCHAR(50) NOT NULL COMMENT 'Indica la direcci�n IP que realiz� el �ltimo cambio' AFTER `CtrlIdUsuario`,
ADD `CtrlDireccionWeb` TEXT NOT NULL COMMENT 'Indica la direcci�n web donde se realiz� el �ltimo cambio' AFTER `CtrlDireccionIp`,
ADD `CtrlCreado` DATETIME NOT NULL COMMENT 'Indica la fecha en la que se cre� el registro' AFTER `CtrlDireccionWeb`,
ADD `CtrlModificado` DATETIME NOT NULL COMMENT 'Indica la fecha en la que se modific� el registro' AFTER `CtrlCreado`;
COMMIT;