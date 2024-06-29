using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

public partial class EgyptianAssociationOfCieliacPatientsContext : DbContext
{
    public EgyptianAssociationOfCieliacPatientsContext()
    {
    }

    public EgyptianAssociationOfCieliacPatientsContext(DbContextOptions<EgyptianAssociationOfCieliacPatientsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AssosiationBranch> AssosiationBranches { get; set; }

    public virtual DbSet<AssosiationBranchPhone> AssosiationBranchPhones { get; set; }

    public virtual DbSet<AssosiationDisesFollow> AssosiationDisesFollows { get; set; }

    public virtual DbSet<AssosiationInsuranceProvide> AssosiationInsuranceProvides { get; set; }

    public virtual DbSet<Clinic> Clinics { get; set; }
    public virtual DbSet<Cart> Carts { get; set; }


    public virtual DbSet<ClinicAssosiationDiscount> ClinicAssosiationDiscounts { get; set; }

    public virtual DbSet<ClinicInsuranceDiscount> ClinicInsuranceDiscounts { get; set; }

    public virtual DbSet<ClinicPhone> ClinicPhones { get; set; }
    public virtual DbSet<ClinicAddress> ClinicAddresses { get; set; }

    public virtual DbSet<Dises> Dises { get; set; }

    public virtual DbSet<DisesMaterialCatogrize> DisesMaterialCatogrizes { get; set; }

    public virtual DbSet<DisesProductCatogrize> DisesProductCatogrizes { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<DoctorClinicWork> DoctorClinicWorks { get; set; }

    public virtual DbSet<DoctorMedicalrecordVeiw> DoctorMedicalrecordVeiws { get; set; }

    public virtual DbSet<DoctorPhone> DoctorPhones { get; set; }


    public virtual DbSet<HealthInsurance> HealthInsurances { get; set; }

    public virtual DbSet<InsuranceAddress> InsuranceAddresses { get; set; }

    public virtual DbSet<InsurancePhone> InsurancePhones { get; set; }

    public virtual DbSet<MedicalRecord> MedicalRecords { get; set; }

    public virtual DbSet<MedicalRecordDrug> MedicalRecordDrugs { get; set; }

    public virtual DbSet<MedicalRecordTest> MedicalRecordTests { get; set; }

	public virtual DbSet<Order> Orders { get; set; }

	public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientAddress> PatientAddresses { get; set; }


    public virtual DbSet<PatientDisesHave> PatientDisesHaves { get; set; }

    public virtual DbSet<PatientPhone> PatientPhones { get; set; }

    public virtual DbSet<PatientProductView> PatientProductViews { get; set; }

    public virtual DbSet<PatientRawmaterialVeiw> PatientRawmaterialVeiws { get; set; }


    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<RawMaterial> RawMaterials { get; set; }

    public virtual DbSet<RawMaterialImage> RawMaterialImages { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Lab> Labs { get; set; }
    public virtual DbSet<LabPhone> LabPhones { get; set; }
    public virtual DbSet<LabAddress> LabAddresses { get; set; }
    public virtual DbSet<LabType> LabTypes { get; set; }
    public virtual DbSet<LabAssosiationDiscount> LabAssociationDiscounts { get; set; }
    public virtual DbSet<LabInsuranceDiscount> LabInsuranceDiscounts { get; set; }
    public virtual DbSet<Pharmacy> Pharmacies { get; set; }
    public virtual DbSet<PharmacyPhone> PharmacyPhones { get; set; }
    public virtual DbSet<PharmacyAddress> PharmacyAddresses { get; set; }
    public virtual DbSet<PharmacyAssosiationDiscount> PharmacyAssociationDiscounts { get; set; }
    public virtual DbSet<PharmacyInsuranceDiscount> PharmacyInsuranceDiscounts { get; set; }
    public virtual DbSet<Hospital> Hospitals { get; set; }
    public virtual DbSet<HospitalPhone> HospitalPhones { get; set; }
    public virtual DbSet<HospitalAddress> HospitalAddresses { get; set; }
    public virtual DbSet<HospitalType> HospitalTypes { get; set; }
    public virtual DbSet<HospitalInsuranceDiscount> HospitalInsuranceDiscounts { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Admin",
                NormalizedName = "admin",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            },
            new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "UserManager",
                NormalizedName = "usermanager",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            },
            new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "StoreManager",
                NormalizedName = "storemanager",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            },
            new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "MedicalManager",
                NormalizedName = "medicalmanager",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            },
             new IdentityRole()
              {
                  Id = Guid.NewGuid().ToString(),
                  Name = "Doctor",
                  NormalizedName = "doctor",
                  ConcurrencyStamp = Guid.NewGuid().ToString(),
              },
              new IdentityRole()
              {
                  Id = Guid.NewGuid().ToString(),
                  Name = "NormalUser",
                  NormalizedName = "normaluser",
                  ConcurrencyStamp = Guid.NewGuid().ToString(),
              }
        );


        modelBuilder.Entity<AssosiationBranch>(entity =>
        {
            entity.Property(e => e.AssosiationId).ValueGeneratedOnAdd();
            entity.HasMany(e => e.Patients).WithOne(e => e.Assosiation).HasForeignKey(e => e.assosiationid);
        });

        modelBuilder.Entity<AssosiationBranchPhone>(entity =>
        {
            entity.HasOne(d => d.Assosiation).WithMany(d => d.PhoneNumbers)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_assosiation_branch_phone_assosiation_branch");
        });

        modelBuilder.Entity<AssosiationDisesFollow>(entity =>
        {
            entity.HasOne(d => d.Assosiation).WithMany(d => d.Dises)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_assosiation_dises_follow_assosiation_branch");

            entity.HasOne(d => d.Dises).WithMany(d => d.Branches)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_assosiation_dises__dises");
        });

        modelBuilder.Entity<AssosiationInsuranceProvide>(entity =>
        {
            entity.HasOne(d => d.Assosiation).WithMany(d => d.insurances)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_assosiation_assosiation_branch");

            entity.HasOne(d => d.Insurance).WithMany(d => d.AssosiationBranches)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_assosiation_health_insurance");
        });

        modelBuilder.Entity<Clinic>(entity =>
        {
            entity.Property(e => e.ClinicId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<ClinicAssosiationDiscount>(entity =>
        {
            entity.HasOne(d => d.Assosiation).WithMany(d => d.clinics)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_clinic_assosiation_discount_assosiation_branch");

            entity.HasOne(d => d.Clinic).WithMany(d => d.branches)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_clinic_assosiation_discount_clinic");
        });

        modelBuilder.Entity<ClinicInsuranceDiscount>(entity =>
        {
            entity.HasOne(d => d.Clinic).WithMany(d => d.insurences)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_clinic_insurance_discount_clinic");

            entity.HasOne(d => d.Insurance).WithMany(d => d.clinics)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_clinic_insurance_discount_health_insurance");
        });

        modelBuilder.Entity<ClinicPhone>(entity =>
        {
            entity.HasOne(d => d.Clinic).WithMany(d => d.clinicphones)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_clinic_phone_clinic");
        });

        modelBuilder.Entity<Dises>(entity =>
        {
            entity.Property(e => e.DisesId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<DisesMaterialCatogrize>(entity =>
        {
            entity.HasOne(d => d.Dises).WithMany(d => d.Materials)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_raw_material_dises_catogrize_dises");

            entity.HasOne(d => d.Material).WithMany(d => d.dises)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_raw_material_dises_catogrize_raw_material");
        });

        modelBuilder.Entity<DisesProductCatogrize>(entity =>
        {
            entity.HasOne(d => d.Dises).WithMany(d => d.Products)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_dises_product_catogrize_dises");

            entity.HasOne(d => d.Product).WithMany(d => d.dises)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_dises_product_catogrize_product");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.Property(e => e.DoctorId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<DoctorClinicWork>(entity =>
        {
            entity.HasOne(d => d.Clinic).WithMany(d => d.Doctors)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_doctor_clinic_work_clinic");

            entity.HasOne(d => d.Doctor).WithMany(d => d.clinics)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_doctor_clinic_work_doctor");
        });

        modelBuilder.Entity<DoctorMedicalrecordVeiw>(entity =>
        {
            entity.HasOne(d => d.Doctor).WithMany(d => d.medicalrecords)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_doctor_medicalrecord_veiw_doctor");

            entity.HasOne(d => d.Record).WithMany(d => d.Doctors)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_doctor_medicalrecord_veiw_medical_record");
        });

        modelBuilder.Entity<DoctorPhone>(entity =>
        {
            entity.HasOne(d => d.Doctor).WithMany(d => d.DoctorPhones)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_doctor_phone_doctor");
        });


        modelBuilder.Entity<HealthInsurance>(entity =>
        {
            entity.Property(e => e.InsuranceId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<InsuranceAddress>(entity =>
        {
            entity.HasOne(d => d.Insurance).WithMany(d => d.addresses)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_insurance_address_health_insurance");
        });

        modelBuilder.Entity<InsurancePhone>(entity =>
        {
            entity.HasOne(d => d.Insurance).WithMany(d => d.PhoneNumbers)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_insurance_phone_health_insurance");
        });

        modelBuilder.Entity<MedicalRecord>(entity =>
        {
            entity.Property(e => e.RecordId).ValueGeneratedOnAdd();
            entity.HasOne(d => d.Patient).WithMany(d => d.Medicalrecords).OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_medical_record-patient");
        });

        modelBuilder.Entity<MedicalRecordDrug>(entity =>
        {
            entity.HasOne(d => d.Record).WithMany(d => d.Drugs)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_medical_record-drug_medical_record");
        });

        modelBuilder.Entity<MedicalRecordTest>(entity =>
        {
            entity.HasOne(d => d.Record).WithMany(d => d.Tests)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_medical_record-test_medical_record");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.Property(e => e.PatientId).ValueGeneratedOnAdd();
            entity.Property(e => e.PatientBloodtype).IsFixedLength();
        });

        modelBuilder.Entity<PatientAddress>(entity =>
        {
            entity.HasOne(d => d.Patient).WithMany(d => d.Addresses)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_patient_address_patient");
        });



        modelBuilder.Entity<PatientDisesHave>(entity =>
        {
            entity.HasOne(d => d.Dises).WithMany(d => d.patients)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_patient_dises-have_dises");

            entity.HasOne(d => d.Patient).WithMany(d => d.Diseses)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_patient_dises-have_patient");
        });

        modelBuilder.Entity<PatientPhone>(entity =>
        {
            entity.HasOne(d => d.Patient).WithMany(d => d.PhoneNumbers).HasConstraintName("FK_patient_phone_patient");
        });

        modelBuilder.Entity<PatientProductView>(entity =>
        {
            entity.HasOne(d => d.Patient).WithMany(d => d.products).HasConstraintName("FK_patient_product_view_patient");

            entity.HasOne(d => d.Product).WithMany(d => d.patients).HasConstraintName("FK_patient_product_view_product");
        });

        modelBuilder.Entity<PatientRawmaterialVeiw>(entity =>
        {
            entity.HasOne(d => d.Material).WithMany(d => d.patients)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_patient_rawmaterial_veiw_raw_material");

            entity.HasOne(d => d.Patient).WithMany(d => d.Materials)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_patient_rawmaterial_veiw_patient");
        });



        modelBuilder.Entity<Payment>(entity =>
        {
            entity.Property(e => e.PaymentId).ValueGeneratedOnAdd();
            entity.Property(e => e.PaymentType).IsFixedLength();
            entity.HasOne(d => d.Order);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.ProductId).ValueGeneratedOnAdd();
            entity.HasOne(d => d.Cart).WithMany(p => p.Products).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasOne(d => d.Product).WithMany(d => d.Images)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_product_image_product");
        });


        modelBuilder.Entity<RawMaterial>(entity =>
        {
            entity.Property(e => e.MaterialId).ValueGeneratedOnAdd();
            entity.HasOne(d => d.Cart).WithMany(p => p.RawMaterials).OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<RawMaterialImage>(entity =>
        {
            entity.HasOne(d => d.Material).WithMany(d => d.Images)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_rawmaterial_image_raw_material");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.Property(e => e.ReservationId).ValueGeneratedOnAdd();
        });


        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderId).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Patient).WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.ClientCascade)
                .HasConstraintName("FK_order_patient");
        
    });
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.Property(e => e.CartId).ValueGeneratedOnAdd();

            entity.HasMany(d => d.RawMaterials).WithOne(p => p.Cart).OnDelete(DeleteBehavior.Cascade);
            entity.HasMany(d => d.Products).WithOne(p => p.Cart).OnDelete(DeleteBehavior.Cascade);

        });
        base.OnModelCreating(modelBuilder);


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
