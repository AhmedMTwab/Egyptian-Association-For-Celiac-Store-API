
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

    [Column("reservation_time")]
    public TimeOnly ReservationTime { get; set; }

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
