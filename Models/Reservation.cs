using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[Table("reservation")]
public partial class Reservation
{
    [Key]
    [Column("reservation_id")]
    public int ReservationId { get; set; }

    [Column("reservation_date")]
    public DateOnly ReservationDate { get; set; }

    [Column("status", TypeName = "text")]
    public string Status { get; set; } = null!;

    [Column("reservation_time")]
    public TimeOnly ReservationTime { get; set; }

    [Column("appointment_type")]
    [StringLength(50)]
    [Unicode(false)]
    public string AppointmentType { get; set; } = null!;

    [Column("book_date")]
    public DateOnly BookDate { get; set; }

    [Column("book_time")]
    public TimeOnly BookTime { get; set; }

    [Column("patient_id")]
    public int PatientId { get; set; }
    [ForeignKey("PatientId")]
    public virtual Patient Patient { get; set; }    

    [Column("clinic_id")]
    public int ClinicId { get; set; }
    [ForeignKey("ClinicId")]
    public virtual Clinic clinic { get; set; }
}
