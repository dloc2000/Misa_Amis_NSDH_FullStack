USE `misa.web08.nsdh.dxloc`;

UPDATE employee 
SET
  DepartmentCode = 'D001' -- DepartmentCode - VARCHAR(20)
 ,DepartmentName = 'Phòng Nhân sự' -- DepartmentName - VARCHAR(100)
WHERE
  DepartmentId = '7686595d-16d5-33b3-0080-e8e2a817c80e' -- EmployeeID - CHAR(36) NOT NULL
;

UPDATE employee 
SET
  DepartmentCode = 'D002' -- DepartmentCode - VARCHAR(20)
 ,DepartmentName = 'Phòng Hội thảo' -- DepartmentName - VARCHAR(100)
WHERE
  DepartmentId = '768f8e64-7d10-20c9-967d-e8c757976496' -- EmployeeID - CHAR(36) NOT NULL
;

UPDATE employee 
SET
  DepartmentCode = 'D003' -- DepartmentCode - VARCHAR(20)
 ,DepartmentName = 'Phòng Thư ký' -- DepartmentName - VARCHAR(100)
WHERE
  DepartmentId = '17120d02-6ab5-3e43-18cb-66948daf6128' -- EmployeeID - CHAR(36) NOT NULL
;

UPDATE employee 
SET
  DepartmentCode = 'D004' -- DepartmentCode - VARCHAR(20)
 ,DepartmentName = 'Phòng Tiếp khách' -- DepartmentName - VARCHAR(100)
WHERE
  DepartmentId = '469b3ece-744a-45d5-957d-e8c757976496' -- EmployeeID - CHAR(36) NOT NULL
;

UPDATE employee 
SET
  DepartmentCode = 'D005' -- DepartmentCode - VARCHAR(20)
 ,DepartmentName = 'Phòng Chủ tịch' -- DepartmentName - VARCHAR(100)
WHERE
  DepartmentId = '11452b0c-768e-5ff7-0d63-eeb1d8ed8cef' -- EmployeeID - CHAR(36) NOT NULL
;

UPDATE employee 
SET
  DepartmentCode = 'D006' -- DepartmentCode - VARCHAR(20)
 ,DepartmentName = 'Phòng Tổng giám đốc' -- DepartmentName - VARCHAR(100)
WHERE
  DepartmentId = '4577565a-7e3e-493a-74dd-867949feb8b5' -- EmployeeID - CHAR(36) NOT NULL
;

UPDATE employee 
SET
  DepartmentCode = 'D007' -- DepartmentCode - VARCHAR(20)
 ,DepartmentName = 'Phòng Lập trình viên' -- DepartmentName - VARCHAR(100)
WHERE
  DepartmentId = '142cb08f-7c31-21fa-8e90-67245e8b283e' -- EmployeeID - CHAR(36) NOT NULL
;

UPDATE employee 
SET
  DepartmentCode = 'D008' -- DepartmentCode - VARCHAR(20)
 ,DepartmentName = 'Phòng Bảo vệ' -- DepartmentName - VARCHAR(100)
WHERE
  DepartmentId = '4e272fc4-7875-78d6-7d32-6a1673ffca7c' -- EmployeeID - CHAR(36) NOT NULL
;