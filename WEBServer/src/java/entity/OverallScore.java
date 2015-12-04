/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package entity;

import java.io.Serializable;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author XRC_7331
 */
@Entity
@Table(name = "overall_score")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "OverallScore.findAll", query = "SELECT o FROM OverallScore o"),
    @NamedQuery(name = "OverallScore.findById", query = "SELECT o FROM OverallScore o WHERE o.id = :id"),
    @NamedQuery(name = "OverallScore.findByValue", query = "SELECT o FROM OverallScore o WHERE o.value = :value")})
public class OverallScore implements Serializable {
    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "id")
    private Integer id;
    @Basic(optional = false)
    @Column(name = "value")
    private int value;
    @JoinColumn(name = "userGame", referencedColumnName = "id")
    @ManyToOne(optional = false)
    private UserGame userGame;

    public OverallScore() {
    }

    public OverallScore(Integer id) {
        this.id = id;
    }

    public OverallScore(Integer id, int value) {
        this.id = id;
        this.value = value;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public int getValue() {
        return value;
    }

    public void setValue(int value) {
        this.value = value;
    }

    public UserGame getUserGame() {
        return userGame;
    }

    public void setUserGame(UserGame userGame) {
        this.userGame = userGame;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (id != null ? id.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof OverallScore)) {
            return false;
        }
        OverallScore other = (OverallScore) object;
        if ((this.id == null && other.id != null) || (this.id != null && !this.id.equals(other.id))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "entity.OverallScore[ id=" + id + " ]";
    }

}
